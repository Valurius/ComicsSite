import React, { useContext } from 'react';
import MyButton from '../components/UI/MyButton/MyButton';
import MyInput from '../components/UI/MyInput/MyInput';
import { AuthContext } from '../context/context';

const Login = () => {
    const{setIsAuth} = useContext(AuthContext)
    const login = event => {
        event.preventDefault();
        setIsAuth(true);
        localStorage.setItem('auth', 'true')
    }

    return (
        <div>
            <h1>Страница для логина</h1>
            <form onSubmit={login}>
                <MyInput type="text" placeholder='Введите логин'></MyInput>
                <MyInput type="password" placeholder='Введите пароль'></MyInput>
                <MyButton> Вход </MyButton>
            </form>
        </div>
    );
};

export default Login;