<template>
    <router-view />
</template>

<style lang="scss">
html,
body,
#app {
    height: 100%;
    margin: 0px;
}

#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    color: #2c3e50;
}

nav {
    padding: 30px;

    a {
        font-weight: bold;
        color: #2c3e50;

        &.router-link-exact-active {
            color: #42b983;
        }
    }
}

h4 {
    font-style: normal;
    font-weight: 500;
    font-size: 2em;
    text-align: center;
    color: #3f434a;
}

span {
    font-style: normal;
    font-weight: 500;
    font-size: 1em;
    color: #8a9099;
}

hr {
    width: 100%;
    size: 1px;
    background: #e8e9eb;
}

a {
    text-decoration: none;

    & span {
        color: #304ffd;
    }
}

input[type="submit"] {
    width: 100%;
    border-radius: 14px;
    height: 40px;
    background-color: #304ffd;
    border-color: #304ffd;
    border-style: solid;
    color: white;
    transition: box-shadow 0.1s ease-in;
}

button {
    width: 100%;
    border-radius: 14px;
    height: 40px;
    background-color: white;
    border-color: #e8e9eb;
    border-style: solid;
    font-size: 15px;
    transition: box-shadow 0.1s ease-in;
}

button span {
    color: #595f69;
}

input[type="submit"],
button {
    box-shadow: 0 3px 5px 0px rgba(0, 0, 0, 0.5);
}

input[type="submit"]:hover,
button:hover {
    border-color: #b3d7ff;
}

input[type="submit"]:active,
button:active {
    box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25);
}

input[type="checkbox"] {
    position: absolute;
    opacity: 0;
}

input[type="checkbox"] + span {
    display: inline-flex;
    align-items: center;
    user-select: none;
}

input[type="checkbox"] + span::before {
    content: "";
    box-sizing: border-box;
    display: inline-block;
    width: 1rem;
    height: 1rem;
    border: 1px solid black;
    border-radius: 0.25em;
    margin-right: 0.5em;
    background-repeat: no-repeat;
    background-position: bottom;
    box-shadow: none;
    transition: box-shadow 0.1s ease-in;
}

input[type="checkbox"]:checked + span::before {
    border-color: #304ffd;
    background-color: #304ffd;
    background-image: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 14 12'%3e%3cpath fill='%23fff' d='M11.7917 1.2358C12.0798 1.53914 12.0675 2.01865 11.7642 2.30682L5.7036 8.06439C5.40574 8.34735 4.93663 8.34134 4.64613 8.05084L2.22189 5.6266C1.92604 5.33074 1.92604 4.85107 2.22189 4.55522C2.51774 4.25937 2.99741 4.25937 3.29326 4.55522L5.19538 6.45734L10.7206 1.20834C11.024 0.920164 11.5035 0.93246 11.7917 1.2358Z'/%3e%3c/svg%3e");
}

input[type="checkbox"]:not(:checked):hover + span:before,
input[type="checkbox"]:not(:checked) + span:hover:before {
    border-color: #b3d7ff;
}

input[type="checkbox"]:active + span:before,
input[type="checkbox"] + span:active:before {
    box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25);
}

input {
    height: 30px;
    border-radius: 14px;
    background-color: white;
    border-color: #e8e9eb;
    border-style: solid;
    padding-left: 10px;
}

input:focus {
    outline: none;
    border-color: #304ffd;
}

.grid {
    display: grid;
    grid-template-columns: auto;
    grid-template-rows: 1fr;
    justify-items: center;
    align-items: center;
    height: 100%;

    &.columns-2 {
        grid-template-columns: 1fr 1fr;
    }
}

.rectangle {
    background-color: white;
    min-width: 300px;
    width: 75%;
    height: 95%;
    border-radius: 14px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-around;
}

.illustration {
    display: flex;
    justify-content: center;
    width: 100%;

    & img {
        width: 95%;
    }
}

.authorization {
    display: flex;
    width: 80%;
    min-width: 250px;
    flex-direction: column;
    align-items: center;
    overflow: hidden;
    padding: 5%;
}

.button-login-google div {
    width: 72.5%;
}

.container-between {
    display: flex;
    width: 100%;
    justify-content: space-between;
    align-items: center;
}

.email-login {
    position: relative;
    margin: 30px 20px;
    width: 100%;
    text-align: center;
    display: flex;
    align-items: center;
}

.email-login hr {
    position: absolute;
}

.email-login span {
    position: relative;
    display: block;
    z-index: 1;
    white-space: nowrap;
    margin: 0 auto;
    color: #8a9099;
    flex-wrap: nowrap;
    overflow: hidden;
    margin: 0 auto;
    text-transform: uppercase;
    font-size: 12px;
    background: white;
}

.form-auth {
    width: 100%;
    display: flex;
    flex-direction: column;
}

.button-login {
    width: 100%;
    border-radius: 14px;
    height: 40px;
    background-color: #304ffd;
    border-color: #304ffd;
    border-style: solid;
    color: white;
}

.forget-password {
    justify-content: center;
    height: auto;
    align-self: center;
}

.form-password {
    border: 2px solid #e8e9eb;
    border-radius: 14px;
    display: grid;
    grid-template-columns: 1fr auto;
    align-items: center;

    & input {
        border: none;
    }

    & img {
        height: 16px;
        width: 16px;
        margin-right: 10px;
    }

    &:focus-within {
        border-color: #304ffd;
    }
}
</style>
