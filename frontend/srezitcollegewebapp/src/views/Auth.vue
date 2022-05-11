<template>
    <div class="grid columns-2">
        <div class="illustration">
            <img src="../assets/preview.png" />
        </div>

        <div class="rectangle">
            <div class="authorization">
                <h4>Авторизация</h4>

                <form @submit.prevent="logIn" class="form-auth">
                    <span>Email</span>
                    <input type="email" v-model="email" />

                    <br />

                    <span>Пароль</span>
                    <div class="form-password">
                        <input :type="passwordType" v-model="password" />
                        <img src="../assets/eyes.png" @click="showPassword()" />
                    </div>

                    <br />

                    <input type="submit" class="button-login" value="Войти" />

                    <br />

                    <div class="container forget-password">
                        <a href="" @click="$router.push('/RestorePassword')">
                            <span>Забыли пароль?</span>
                        </a>
                    </div>
                </form>
            </div>

            <footer>
                <span> Ещё нет аккаунта? </span>

                <a href="" @click="$router.push('/Registration')">
                    <span>Зарегистрироваться</span>
                </a>
            </footer>
        </div>
    </div>
</template>

<script>
import axios from "axios";

export default {
    data() {
        return {
            email: "",
            password: "",
            passwordType: "password",
            userId: -1,
        };
    },

    methods: {
        async logIn() {
            try {
                var request = await axios.post(
                    `http://192.168.0.103:5000/api/Users/Authorization/${this.email}/${this.password}`
                );

                if (request.data == -1) {
                    alert("Неправильный логин или пароль");
                    return;
                }

                this.$router.push(`/${request.data}/Welcome`);
            } catch (ex) {
                console.log(ex);
            }
        },

        showPassword() {
            this.passwordType =
                this.passwordType === "password" ? "text" : "password";
        },
    },

    created() {
        document.title = "Авторизация";
    },
};
</script>

<style lang="scss">
.grid {
    background-color: #304ffd;
}
</style>