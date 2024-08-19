import { View, Text } from 'react-native'
import React from 'react'
import { createDrawerNavigator } from '@react-navigation/drawer'
import AdminInbox from './AdminInbox';
import AdminProfile from './AdminProfile';

export default function AdminHandler({currentUser}) {
    const Drawer = createDrawerNavigator();
  
    return (
        <Drawer.Navigator
            initialRouteName='AdminInbox'
        >
            <Drawer.Screen
                name='AdminInbox'
            >
                {props => <AdminInbox {...props} />}
            </Drawer.Screen>

            <Drawer.Screen
                name='AdminProfile'
            >
                {props => <AdminProfile {...props} currentUser={currentUser} />}
            </Drawer.Screen>
        </Drawer.Navigator>    
    )
}