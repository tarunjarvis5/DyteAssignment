import React, { Component } from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';

export const Layout = (props) => {

        return (
            <div className="entire" >
                <NavMenu />
                <div className="main-container">
                    {props.children}
                </div>
            </div>
        );
    }
