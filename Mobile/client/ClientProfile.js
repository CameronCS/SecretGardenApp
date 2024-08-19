import React, { useState } from 'react';
import { View, Text, TextInput, Image, Button, StyleSheet } from 'react-native';
import RNPickerSelect from 'react-native-picker-select';

export default function UserProfile({ navigation, currentUser }) {
    const [selectedProfile, setSelectedProfile] = useState('user');
    const [profileData, setProfileData] = useState(currentUser);

    const handleProfileChange = (itemValue) => {
        if (itemValue === 'user') {
            setProfileData(currentUser);
        } else {
            const selectedChild = currentUser.children.find(child => child.firstname === itemValue);
            setProfileData(selectedChild);
        }
        setSelectedProfile(itemValue);
    };

    const handleLogout = () => {
        navigation.navigate("Login");
    };

    return (
        <View style={styles.container}>
            <Text style={styles.profileText}>Profile</Text>
            <View style={styles.profileContainer}>
                <RNPickerSelect
                    onValueChange={handleProfileChange}
                    value={selectedProfile}
                    items={[
                        { label: `${currentUser.firstname} (You)`, value: 'user' },
                        ...currentUser.children.map(child => ({
                            label: child.firstname,
                            value: child.firstname,
                        })),
                    ]}
                    style={pickerStyles}
                />

                <Image
                    source={{ uri: `http://192.168.0.173:3050${profileData.imageurl}` }}
                    style={styles.profileImage}
                />
                <View style={styles.detailsContainer}>
                    <Text style={styles.label}>First Name:</Text>
                    <TextInput
                        value={profileData.firstname}
                        editable={false}
                        style={[styles.textInput, styles.readOnlyInput]}
                    />
                    <Text style={styles.label}>Last Name:</Text>
                    <TextInput
                        value={profileData.lastname}
                        editable={false}
                        style={[styles.textInput, styles.readOnlyInput]}
                    />
                    <Text style={styles.label}>{selectedProfile === 'user' ? 'Username' : 'Class Name'}:</Text>
                    <TextInput
                        value={selectedProfile === 'user' ? profileData.username : profileData.classname}
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
    picker: {
        height: 50,
        width: 300,
        marginBottom: 20,
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
    readOnlyInput: {
        color: '#000000',
        backgroundColor: '#FFFFFF',
    },
    buttonContainer: {
        marginTop: 20,
    }
});

const pickerStyles = StyleSheet.create({
    inputIOS: {
        height: 50,
        width: 300,
        backgroundColor: '#FFFFFF',
        borderColor: '#CCCCCC',
        borderWidth: 1,
        borderRadius: 5,
        paddingHorizontal: 10,
        marginBottom: 20,
    },
    inputAndroid: {
        height: 50,
        width: 300,
        backgroundColor: '#FFFFFF',
        borderColor: '#CCCCCC',
        borderWidth: 1,
        borderRadius: 5,
        paddingHorizontal: 10,
        marginBottom: 20,
    },
    placeholder: {
        color: '#999999',
    },
});
