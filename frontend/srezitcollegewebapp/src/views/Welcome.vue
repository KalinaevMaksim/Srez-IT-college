<template>
    <div class="grid">
        <div class="rectangle">
            <div class="authorization">
                <img
                    :src="`data:image;base64,${user.photo}`"
                    v-show="user.photo != null"
                />
                <img src="../assets/man.png" v-show="user.photo === null" />

                <h4>Добро пожаловать</h4>

                <form class="form-auth" action="change-password.html">
                    <h2>{{ user.lastName }}</h2>
                    <h2>{{ user.firstName }}</h2>
                    <h2>{{ user.patronomyc }}</h2>

                    <br />

                    <input
                        type="submit"
                        class="button-reg"
                        value="Выход"
                        @click="$router.push('/')"
                    />
                </form>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";

export default {
    data() {
        return {
            user: Object,
        };
    },

    created() {
        document.title = "Добро пожаловать";
    },

    async mounted() {
        try {
            let request = await axios.get(
                `http://192.168.0.103:5000/api/Users/InfoUser/${this.$route.params.userId}`
            );

            if(request.data === -1) {
                alert("Такого пользователя не существует");
                return;
            }

            this.user = request.data;
        } catch (ex) {
            console.log(ex);
        }
    },
};
</script>

<style lang="scss" scoped>
h2 {
    font-weight: normal;
}

.authorization img {
    max-height: 150px;
}

.form-auth {
    text-align: center;
}

.grid {
    background-color: #e9f3f5;
}

.rectangle {
    width: 40%;
}
</style>