import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const store = new Vuex.Store({
  state: {
    currentUser: null
  },
  getters: {
    loggedIn (state) {
      return state.currentUser !== null
    }
  },
  actions: {
    async init ({ state }) {
      const { data } = await axios.get('/api/init')
      state.currentUser = data.currentUser
    },
    async login ({ dispatch }, form) {
      await axios.post('/account/login', form)
      await dispatch('init')
    },
    async logout ({ state }) {
      await axios.get('/account/logout')
      state.currentUser = null
    }
  }
})

export default store
