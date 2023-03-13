import React, { useContext } from 'react';
import {Link } from "react-router-dom";
import { AuthContext } from '../../../context/context';
import MyButton from '../MyButton/MyButton';
import classes from './Navbar.module.css'

const Navbar = () => {
  const {setIsAuth} = useContext(AuthContext);

  const logout = () => {
    setIsAuth(false);
    localStorage.removeItem('auth')
  }

    return (
        <div className={classes.navbar}>
          <MyButton onClick={logout}>
            Выйти
          </MyButton>
        <div className={classes.navbar__links}>
          <Link to="/about">About</Link>
          <Link to="/posts"> Comics</Link>
        </div>
      </div>
    );
};

export default Navbar;