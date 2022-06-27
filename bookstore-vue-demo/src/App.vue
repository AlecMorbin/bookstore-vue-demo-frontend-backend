<template>
  <nav class="nav">
    <img src="./assets/Logo.png" alt="Logo">
    <a class="nav-link active" aria-current="page" href="#">Active</a>
    <a class="nav-link" href="#">Link</a>
    <a class="nav-link" href="#">Link</a>
    <a class="nav-link disabled">Disabled</a>
  </nav>
  <div class="container">
    <DetailsView />
  </div>
</template>

<script>
import DetailsView from './components/DetailsView.vue'

export default {
  name: 'App',
  components: {
     DetailsView,
  }
}
</script>

<style>
    @import 'https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css ';
    @import 'https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css';
</style>
