"use strict"

window.scrollToFragment = (elementId) => {
    let element = document.getElementById(elementId)
    
    if (element != null)
        element.scrollIntoView({behavior: 'smooth'})
}
