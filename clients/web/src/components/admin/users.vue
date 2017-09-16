<template>
  <div>
    <ul>
      <li v-for="user of users">
        {{ user.userName }}
      </li>
    </ul>
  </div>
</template>

<script>
import Routed from '@/mixins/routed'

export default {
  mixins: [new Routed({ dataURL: '/api/admin/users' })],
  data () {
    return {
      users: []
    }
  }
}
</script>

<style>

</style>
