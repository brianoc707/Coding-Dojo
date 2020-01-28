import React, { useEffect, useState } from 'react';

import Home from '../components/Home';


export default () => {

    
    return(
        <>
        <Home />
        <audio controls>
        <source src="media/fuk_2.mp3" type="audio/mpeg" />
        </audio>
        </>
    )
}