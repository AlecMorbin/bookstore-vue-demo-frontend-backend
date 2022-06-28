<template>
  <nav class="nav">
    <img src="./assets/Logo.png" alt="Logo">
    <router-link class="nav-link" to="/">Home</router-link>
    <router-link class="nav-link" to="/addbook">Add Book</router-link>
  </nav>
  <div class="container">
      <router-view />
  </div>
</template>

<script>
export default {
  name: 'App',
  components: {
  }
}
</script>

<style>
    @import 'https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css ';
    @import 'https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css';
</style>
