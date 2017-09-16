import Vue from 'vue'
import Router from 'vue-router'

import Home from 

Vue.use(Router)

const router = new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      component: () => import('@/components/home.vue')
    }
    // {
    //   path: '/login',
    //   component: () => import('@/components/login.vue')
    // },
    // {
    //   path: '/admin',
    //   component: { template: '<router-view/>' },
    //   children: [
    //     {
    //       path: 'users',
    //       component: () => import('@/components/admin/users.vue')
    //     }
    //   ]
    // }
  ]
})

router.beforeEach((to, from, next) => {
  console.log(to.path)
  next()
})

router.onError(error => {
  if (error && error.response && error.response.status === 401) {
    router.push('/login')
  }
})

export default router
