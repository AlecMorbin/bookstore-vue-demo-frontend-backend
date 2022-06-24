<template>
    <div class="row">
        <div class="col-12 text-center">
            <h1>Benvenuto Admin!</h1>
            <p>Da qui potrai modificare, eliminare, aggiungere un nuovo libro o ordinarne libri già presenti</p>
        </div>
    </div>
    <div class="row mb-3">
        <div class="col-lg-3 col-md-6 col-12 mx-auto mb-3">
            <a class="btn btn-outline-primary w-100" href="" role="button">Aggiunngi un nuovo libro</a>
        </div>
        <div class="text-center">
            <form method="get" id="quantityCheck">
                <div class="d-flex justify-content-around">
                    <div class="d-block">
                        <input class="m-1" type="radio" id="danger" value="0" name="quantityFilter"/>
                        <label for="danger">Scorte Magazzino finite</label>
                    </div>
                    <div class="d-block">
                        <input class="m-1" type="radio" id="warning" value="9" name="quantityFilter"/>
                        <label for="warning">Scorte Magazzino a rischio</label>
                    </div>
                    <div class="d-block">
                        <input class="m-1" type="radio" id="ok" value="10" name="quantityFilter"/>
                        <label for="ok">Scorte Magazzino normali</label><br />
                    </div>
                    <div class="d-block">
                        <input class="m-1" type="radio" id="nofilter" value="null" name="quantityFilter"/>
                        <label for="nofilter">Nessun filtro</label><br />
                    </div>
                </div>
                <div class="mt-1">
                    <input type="text" placeholder="Cerca..." name="search" />
                    <input  type="submit" value="Cerca" />
                </div>
            </form>
        </div>
    </div>
    <div class="row">
        <div v-if="loading" class="loading col-12">
            <p class="text-center">Loading...</p>
        </div>

        <div v-if="books" class="content row">
            <div class="col-12">
                <table class="table">
                    <thead>
                        <tr class="table-primary">
                            <th>ID</th>
                            <th>Immagine</th>
                            <th>Informazioni</th>
                            <th>Categoria</th>
                            <th>Prezzo</th>
                            <th>Quantità rimanente</th>
                            <th>Azioni</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="book in books" :key="book.id">
                                <td>{{book.id}}</td>
                                <td><img :src="book.urlImage" alt="Copertina libro" width="300"/></td>
                                <td><div class="fs-5"><strong>{{book.title}}</strong> - <span><em>{{book.author}}</em></span></div> <p class="mt-2">{{book.description}}</p></td>
                                <td>{{book.category.name}}</td>
                                <td>{{book.price}}</td>
                                <td>{{book.quantity}}
                                    <i v-if="book.quantity <= 0" class="fa-solid fa-triangle-exclamation text-danger"></i>
                                    <i v-else-if="book.quantity <= 9" class="fa-solid fa-triangle-exclamation text-warning"></i>
                                </td>
                                <td></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                loading: false,
                books: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.post = null;
                this.loading = true;

                fetch('https://localhost:5001/api/bookstore/get')
                    .then(r => r.json())
                    .then(json => {
                        this.books = json;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>