import { createApp } from 'vue'
import App from './App.vue'
import { createRouter,createWebHistory } from 'vue-router'

import Home from  './components/AdminView.vue'
import Details from './components/DetailsView.vue'
import NotFound from './components/NotFound.vue'
import AddBook from './components/AddBookView.vue'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home,
    },
    {
        path: '/details/:id',
        name: 'Details',
        component: Details,
        props: true,
    },
    {
        path: '/addbook',
        name: 'AddBook',
        component: AddBook,
    },
    {
        path: '/:catchAll(.*)',
        name: 'NotFound',
        component: NotFound,
    },
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})


createApp(App).use(router).mount('#app')
