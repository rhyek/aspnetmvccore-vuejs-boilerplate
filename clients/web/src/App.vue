<template>
  <div id="app" v-if="!loading">
    hey
    <button v-if="$store.getters.loggedIn" type="button" @click="logout">Cerrar sesión</button>
    <router-view></router-view>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'
import { Prop } from 'vue-property-decorator'

@Component
export default class extends Vue {
  @Prop()
  name = 'app'

  loading = true

  async created () {
    try {
      await this.$store.dispatch('init')
    }
    catch (e) {}
    this.loading = false
  }

  async logout () {
    await this.$store.dispatch('logout')
    this.$router.push('/login')
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
</style>
