<template>
    <div class="row">
        <div class="col-12 text-center">
            <h1>Benvenuto nella pagina di aggiunta di un nuovo libro!</h1>
            <p>Da qui potrai aggiungere un nuovo libro</p>
        </div>
    </div>
    <div class="row">
        <div class="col shadow-lg rounded">
            <form @submit.prevent="sendForm()" class="row">
                <div class="col-md-6 col-12 my-2">
                    <span>Titolo libro:</span>
                    <input required type="text" class="form-control" v-model="book.title"/>
                </div>
                <div class="col-md-6 col-12 my-2">
                    <span>Autore:</span>
                    <input required type="text" class="form-control" v-model="book.author"/>
                </div>
                <div class="col-12 my-2">
                    <span>Url immagine:</span>
                    <input required type="url" class="form-control" v-model="book.urlImage" />
                </div>
                <div class="col-12 my-2">
                    <span>Descrizione:</span>
                    <input required type="text" class="form-control"  rows="4" v-model="book.description"/>
                </div>
                <div class="col-md-6 col-12 my-2">
                    <span>Prezzo:</span>
                    <input required type="number" class="form-control price"  min=0 step="0.01" v-model="book.price"/>
                </div>
                <div class="col-md-6 col-12 my-2">
                    <span>Categoria:</span>
                    <select required  class="form-select" aria-label="Default select example" v-model="book.category.id">
                      <option selected>Seleziona una categoria</option>
                      <option v-for="cat in categories" :key="cat.id" :value="cat.id">{{cat.name}}</option>
                    </select>
                </div>
                <div class="text-end my-2">
                    <input type="submit" class="btn btn-small btn-success" value="Aggiungi">
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
export default {
    data() {
        return {
            book: {
                category: {},
            },
            categories: [],
        }
    },
    created() {
        this.fetchData()
    },
    methods: {
        async fetchData() {
            await axios
                .get('https://localhost:5001/Api/BookStore/GetCategories')
                .then((res) => {
                    console.log('success',res);
                    this.categories = res.data;
                    })
                .catch(err => console.log('error',err))
        },
        sendForm(){
            axios
                .post('https://localhost:5001/Api/BookStore/Create',this.book)
                .then(res => console.log(res))
                .catch(err => {
                    console.log('error',err)
                    console.log(err.config.data)
                })
        }
    }
}
</script>

<style>

</style>