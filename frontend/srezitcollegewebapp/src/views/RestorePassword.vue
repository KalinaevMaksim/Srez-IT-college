<template>
    <div class="grid">
        <div class="rectangle">
            <div class="authorization">
                <img src="../assets/lock.png" style="max-width: 120px" />

                <h4>Восстановление пароля</h4>

                <form class="form-auth" @submit.prevent="restore">
                    <span>Email</span>
                    <input type="email" v-model="email" />

                    <br />

                    <input
                        type="submit"
                        class="button-reg"
                        value="Восстановить пароль"
                    />
                </form>
            </div>
            <footer style="margin-top: 30px">
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
        };
    },

    methods: {
        async restore() {
            if (this.email.length === 0) {
                alert("Заполните поле email");
                return;
            }

            try {
                let request = await axios.post(
                    `http://192.168.0.103:5000/api/Users/RestorePassword/${this.email}`
                );

                if (request.data === -1) {
                    alert("Такого email не существует");
                    return;
                }

                this.$router.push(`/ChangePassword`);
            } catch (ex) {
                console.log(ex);
            }
        },
    },

    created() {
        document.title = "Восстановление пароля";
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