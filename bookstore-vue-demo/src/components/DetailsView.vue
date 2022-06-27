<template >
  <div class="container">
    <div class="row" v-if="!book">
      <p>Loading...</p>
    </div>
    <div v-else>
      <div class="row">
        <div class="col fw-bold fs-2" id="titolo">
          {{ book.title }}
        </div>
      </div>
      <div class="row mt-2">
        <div v-if="category" class="col fst-italic" id="categoria">
          {{ book.category.name }}
        </div>
      </div>
      <div class="row mt-3">
        <div
          class="col-md-3 col-12 shadow-lg p-0 mb-2 bg-body rounded"
          id="immagine"
        >
          <img :src="book.urlImage" class="w-100" :alt="book.title" />
        </div>
        <div
          class="col-md-9 col-12"
          id="descrizione"
          style="text-align: center"
        >
          {{ book.description }}
        </div>
      </div>
      <div class="row mt">
        <div class="col-md-1 col-6 fw-bold pt-2 text-start" id="like">
          {{ book.numberOfLikes }}<i class="fa-solid fa-heart"></i>
        </div>
        <div class="col-md-2 col-6 fw-bold pt-2 text-end" id="copie-rimanenti">
          {{ book.quantity }}<i class="fa-solid fa-copy"></i>
        </div>
        <div class="col-md-9 text-end fw-bold fst-italic">
          {{ book.price }} &euro;
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "DetailsView",
  mounted: function () {
    axios
      .get("https://localhost:5001/Api/BookStore/Details?id=7")
      .then((res) => {
        this.book = res.data;
        this.category = res.data.category;
      });
  },
  data() {
    return {
      book: null
    };
  },
};
</script>

<style>
@import "https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css ";
@import "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css";
</style>
