<template>
    <div class="grid">
        <div class="rectangle">
            <div class="authorization">
                <h4>Регистрация</h4>

                <form class="form-auth" @submit.prevent="registration">
                    <span>ФИО</span>
                    <input type="text" v-model="fio" />
                    <br />

                    <span>Email</span>
                    <input type="email" v-model="email" />

                    <br />

                    <span>Пароль</span>
                    <div class="form-password">
                        <input :type="passwordTypeFirst" v-model="password" />
                        <img
                            src="../assets/eyes.png"
                            @click="showPasswordFirst()"
                        />
                    </div>

                    <br />

                    <span>Подтверждение пароля</span>
                    <div class="form-password">
                        <input
                            :type="passwordTypeSecond"
                            v-model="repeatPassword"
                        />
                        <img
                            src="../assets/eyes.png"
                            @click="showPasswordSecond()"
                        />
                    </div>

                    <br />

                    <input
                        type="submit"
                        class="button-reg"
                        value="Зарегистрироваться"
                    />
                </form>
            </div>
            <footer style="margin-top: 30px">
                <span> Уже есть аккаунт? </span>

                <a href="" @click="$router.push('/')">
                    <span>Войти</span>
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
            fio: "",
            email: "",
            password: "",
            repeatPassword: "",
            passwordTypeFirst: "password",
            passwordTypeSecond: "password",
        };
    },

    created() {
        document.title = "Регистрация";
    },

    methods: {
        async registration() {
            if (
                this.fio.length === 0 ||
                this.email.length === 0 ||
                this.password.length === 0 ||
                this.repeatPassword.length === 0
            ) {
                alert("Заполните все поля");
                return;
            }

            if (this.password != this.repeatPassword) {
                alert("Пароли не совпадают");
                return;
            }

            const names = this.fio.split(" ");

            if (names.length != 3) {
                alert("В ФИО должно быть 3 слова");
                return;
            }

            try {
                let request = await axios.post(
                    `http://192.168.0.103:5000/api/Users/RestorePassword/${this.email}`
                );

                if (request.data != -1) {
                    alert("Такой email уже существует");
                    return;
                }

                await axios.post(
                    `http://192.168.0.103:5000/api/Users/Registration/${this.fio}/${this.email}/${this.password}`
                );

                alert("Пользователь успешно зарегистрирован");

                this.$router.push("/");
            } catch (ex) {
                console.log(ex);
            }
        },

        showPasswordFirst() {
            this.passwordTypeFirst =
                this.passwordTypeFirst === "password" ? "text" : "password";
        },

        showPasswordSecond() {
            this.passwordTypeSecond =
                this.passwordTypeSecond === "password" ? "text" : "password";
        },
    },
};
</script>

<style lang="scss" scoped>
.grid {
    background-color: #e9f3f5;
}

.rectangle {
    width: 40%;
}
</style>