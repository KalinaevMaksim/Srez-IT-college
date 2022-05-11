import { createRouter, createWebHistory } from 'vue-router'
import Auth from '../views/Auth.vue'
import Reg from '../views/Registration.vue'
import RestorePassword from '../views/RestorePassword.vue'
import ChangePassword from '../views/ChangePassword.vue'
import Welcome from '../views/Welcome.vue'

const routes = [
  {
    path: '/',
    name: 'auth',
    component: Auth
  },
  {
    path: '/Registration',
    name: 'reg',
    component: Reg
  },
  {
    path: '/RestorePassword',
    name: 'restorePassword',
    component: RestorePassword
  },
  {
    path: '/ChangePassword',
    name: 'changePassword',
    component: ChangePassword
  },
  {
    path: '/:userId/Welcome',
    name: 'welcome',
    component: Welcome
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router