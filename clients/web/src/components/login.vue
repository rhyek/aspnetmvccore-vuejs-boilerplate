<template>
  <div>
    <form action="/account/login" method="post" @submit.prevent="login">
      <div class="form-group">
        <label>Usuario</label>
        <input type="text" v-model="form.UserName">
      </div>
      <div class="form-group">
        <label>Contraseña</label>
        <input type="password" v-model="form.Password">
      </div>
      <button type="submit">Ingresar</button>
    </form>
  </div>
</template>

<script>
import showError from '@/utils/show-error'

export default {
  data () {
    return {
      form: {
        UserName: null,
        Password: null
      }
    }
  },
  methods: {
    async login () {
      try {
        await this.$store.dispatch('login', this.form)
        this.$router.push('/')
      }
      catch (e) {
        showError(e)
        throw e
      }
    }
  }
}
</script>

<style>

</style>
