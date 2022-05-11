<template>
    <div class="grid">
        <div class="rectangle">
            <div class="authorization">
                <img src="../assets/lock.png" style="max-width: 120px" />

                <h4>Изменение пароля</h4>

                <form class="form-auth" @submit.prevent="change">
                    <span>Email</span>
                    <input type="email" v-model="email" />

                    <br />

                    <span>Новый пароль</span>
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
                        value="Изменить пароль"
                    />
                </form>

                <br />
            </div>
            <footer>
                <span> Обратно к </span>

                <a href="" @click="$router.push('/')">
                    <span>Авторизации</span>
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
            repeatPassword: "",
            passwordTypeFirst: "password",
            passwordTypeSecond: "password",
        };
    },

    created() {
        document.title = "Изменение пароля";
    },

    methods: {
        async change() {
            try {
                if (
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

                let request = await axios.post(
                    `http://192.168.0.103:5000/api/Users/RestorePassword/${this.email}`
                );

                if (request.data === -1) {
                    alert("Такого email не существует");
                    return;
                }

                request = await axios.post(
                    `http://192.168.0.103:5000/api/Users/ChangePassword/${this.email}/${this.password}`
                );

                alert("Пароль успешно изменён");

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