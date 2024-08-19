import React, { useState } from 'react';
import { View, Text, TextInput, Image, Button, StyleSheet } from 'react-native';

export default function AdminProfile({ navigation, currentUser }) {
    const handleLogout = () => {
        navigation.navigate("Login");
    };

    return (
        <View style={styles.container}>
            <Text style={styles.profileText}>Profile</Text>
            <View style={styles.profileContainer}>
                <Image
                    source={{ uri: `http://192.168.0.173:3050${currentUser.imageurl}` }}
                    style={styles.profileImage}
                />
                <View style={styles.detailsContainer}>
                    <Text style={styles.label}>First Name:</Text>
                    <TextInput
                        value={currentUser.firstname}
                        editable={false}
                        style={[styles.textInput, styles.readOnlyInput]}
                    />
                    <Text style={styles.label}>Last Name:</Text>
                    <TextInput
                        value={currentUser.lastname}
                        editable={false}
                        style={[styles.textInput, styles.readOnlyInput]}
                    />
                    <Text style={styles.label}>Contact Number:</Text>
                    <TextInput
                        value={currentUser.contactno}
                        editable={false}
                        style={[styles.textInput, styles.readOnlyInput]}
                    />
                </View>
            </View>
            <View style={styles.buttonContainer}>
                <Button title='Log Out' onPress={handleLogout} color="#FF69B4"/>
            </View>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#F6A1F8',
        alignItems: 'center',
        justifyContent: 'center',
    },
    profileText: {
        fontSize: 24,
        fontWeight: 'bold',
        marginBottom: 20,
        color: '#FFFFFF',
    },
    profileContainer: {
        alignItems: 'center',
        marginBottom: 30,
    },
    profileImage: {
        width: 100,
        height: 100,
        borderRadius: 50,
        marginBottom: 20,
        borderWidth: 2,
        borderColor: '#FFFFFF',
    },
    detailsContainer: {
        backgroundColor: '#FFFFFF',
        borderRadius: 10,
        padding: 20,
        width: 300,
        shadowColor: "#000",
        shadowOffset: {
            width: 0,
            height: 2,
        },
        shadowOpacity: 0.25,
        shadowRadius: 3.84,
        elevation: 5,
    },
    label: {
        fontSize: 16,
        marginBottom: 5,
        color: '#333333',
    },
    textInput: {
        height: 40,
        borderColor: '#CCCCCC',
        borderWidth: 1,
        borderRadius: 5,
        marginBottom: 15,
        paddingHorizontal: 10,
        backgroundColor: '#F8F8F8',
    },
    buttonContainer: {
        marginTop: 20,
    },
    readOnlyInput: {
        color: '#000000', // Override text color to ensure it stays black
        backgroundColor: '#FFFFFF', // Override the background color to white
    }
});
