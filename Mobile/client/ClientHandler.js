import { View, Text } from 'react-native'
import React from 'react'
import { createDrawerNavigator } from '@react-navigation/drawer'
import ClientInbox from './ClientInbox';
import ClientProfile from './ClientProfile';

export default function ClientHandler({currentUser}) {
    const Drawer = createDrawerNavigator();
    return (
    <Drawer.Navigator
        initialRouteName='ClientInbox'
    >
        <Drawer.Screen
            name='ClientInbox'
        >
            {props => <ClientInbox {...props} />}
        </Drawer.Screen>
        <Drawer.Screen
            name='ClientProfile'
        >
            {props => <ClientProfile {...props} currentUser={currentUser} />}
        </Drawer.Screen>
    </Drawer.Navigator>
  )
}