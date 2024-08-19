import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import Login from './shared/Login';
import ClientHandler from './client/ClientHandler';
import AdminHandler from './admin/AdminHandler';
import { useState } from 'react';
import { user } from './consts/userobj';

export default function App() {

  const [currentUser, setCurrentUser] = useState({});

  const URL = "192.168.0.173:3050"

  const Stack = createStackNavigator();

  return (
    <NavigationContainer>
      <Stack.Navigator 
        initialRouteName='Login'
        screenOptions={{headerShown: false}}  
      >
        <Stack.Screen
          name='Login'
        >
          {props => <Login {...props} url={URL} setCurrentUser={setCurrentUser} />}
        </Stack.Screen>

        <Stack.Screen
          name='User'
        >
          {props => <ClientHandler {...props} currentUser={currentUser} />}
        </Stack.Screen>

        <Stack.Screen
          name='Admin'
        >
          {props => <AdminHandler {...props} currentUser={currentUser}/>}
        </Stack.Screen>
      </Stack.Navigator>
    </NavigationContainer>
  );
}