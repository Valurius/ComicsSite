import React, { useContext } from 'react';
import { Route, Routes } from 'react-router-dom';
import { AuthContext } from '../context/context';
import Login from '../pages/Login';
import Posts from '../pages/Posts';
import { publicRoutes, privateRoutes } from '../router/router';
import Loader from './UI/Loader/Loader';

const AppRouter = () => {
    const {isAuth, isLoading} = useContext(AuthContext);

    if(isLoading) {
        return <Loader/>
    }

    return (
        isAuth
            ? <Routes>
                {privateRoutes.map(route =>
                    <Route              
                        key={route.path}  
                        element={route.element}
                        path={route.path}
                    />
                )}
                <Route path="*" element={<Posts />} />
            </Routes>

            : <Routes>        
                {publicRoutes.map(route =>
                    <Route
                        key={route.path} 
                        element={route.element}
                        path={route.path}
                    />
                )}
                <Route path="*" element={<Login/>} />
            </Routes>
    );
};

export default AppRouter;