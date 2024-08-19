import React, { useState } from 'react';
import { View, Text, TextInput, Button, StyleSheet, Image, Alert } from 'react-native';
import axios from 'axios';

export default function LoginPage({url, setCurrentUser, navigation}) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

    const logo = require("../assets/logo.png")

  const usernameTextChanged = (txt) => {
    setUsername(txt)
  }

  const passwordTextChanged = (txt) => {
    setPassword(txt)
  }

  const btnSigningClick = () => {
    const data = {
        username: username,
        password: password
    }

    axios.post(`http://${url}/user/login`, data, {
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then(result => {
        var {user} = result.data;
        if (result.status === 200) {
            Alert.alert("Login", "Logged In");
            if (result.data.user.isAdmin) {
                navigation.navigate("Admin")
                setCurrentUser(user)
            } else {
                axios.get(`http://${url}/user/children/${user._id}`)
                .then(result => {
                    if (result.status === 200) {
                        const {children} = result.data
                        user = {...user, children}
                    } else if (result.status === 404) {
                        Alert.alert("ERR", "There are an error!")
                    } else if (result.status === 500) {
                        Alert.alert("ERR", "Internal Server Error")
                    }
                    navigation.navigate("User")
                    setCurrentUser(user)
                })
                .catch(err => console.log(err))
                
            }
        } else if (result.status === 401) {
            Alert.alert("Login", "Username or password incorrect");
        } else {
            Alert.alert("Login", "Internal Server Error");
        }
    })
    .catch(err => {
        console.log(err);
    })
  }


  return (
    <View style={styles.container}>
      <Image source={logo} style={styles.logo} />
      <Text style={styles.label}>Username</Text>
      <TextInput style={styles.input} placeholder="Enter your username" onChangeText={usernameTextChanged} />
      <Text style={styles.label}>Password</Text>
      <TextInput style={styles.input} placeholder='Enter your password' secureTextEntry onChangeText={passwordTextChanged} />
      <Button title="Sign in" onPress={btnSigningClick} />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F6A1F8',
  },
  logo: {
    width: 200,
    height: 200,
    marginBottom: 20,
  },
  label: {
    fontSize: 18,
    marginVertical: 10,
  },
  input: {
    width: '80%',
    height: 40,
    borderColor: 'gray',
    borderWidth: 1,
    paddingLeft: 10,
    marginBottom: 20,
    borderRadius: 5,
  },
  options: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    width: '80%',
  },
  rememberMe: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  forgotPassword: {
    color: 'blue',
  },
});
