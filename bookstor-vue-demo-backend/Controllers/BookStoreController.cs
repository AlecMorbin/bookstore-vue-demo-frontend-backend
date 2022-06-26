using bookstore_vue_demo_backend.Data;
using bookstore_vue_demo_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookstore_vue_demo_backend.Controllers.Api
{
    [Route("Api/[controller]/[action]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? category , string? searchString)
        {

            IQueryable<Book> books = null;
            using(BookStoreContext db = new BookStoreContext())
            {
                books = db.Books;

                if (category != "Tutte le categorie" && !String.IsNullOrEmpty(category))
                {
                    books = books.Where(book => book.Category.Name == category);
                }

                if (!String.IsNullOrEmpty(searchString) && searchString != "undefined")
                {
                    books = books.Where(book => book.Author.ToLower().Contains(searchString) || book.Title.ToLower().Contains(searchString));
                }


                if(books == null)
                return Ok(books.Include(book => book.Category).ToList());
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult AdminGet(int? quantityFilter, string? search)
        {
            IQueryable<Book>? books = null;
            using (BookStoreContext db = new())
            {
                books = db.Books;

                if (!String.IsNullOrEmpty(search))
                {
                    books = db.Books.Where(book => book.Author.ToLower().Contains(search) || book.Title.ToLower().Contains(search));
                }

                if(quantityFilter != null)
                {
                    if (quantityFilter <= 0)
                    {
                        books = books.Where(book => book.Quantity <= 0);
                    }
                    else if (quantityFilter <= 9)
                    {
                        books = books.Where(book => book.Quantity <= 9 && book.Quantity > 0);
                    }
                    else if (quantityFilter > 9)
                    {
                        books = books.Where(book => book.Quantity > 9);
                    }
                }


                if (books != null)
                {
                    return Ok(books.Include(book => book.Category).ToList());
                }
            }


            return NotFound();
        }

        /*

        [HttpGet]
        public IActionResult AdminGet(int? quantityFilter, string? search)
        {
            using (BookStoreContext db = new BookStoreContext())
            {
                if (quantityFilter <= 0)
                {
                    List<Book> books = db.Books.Where(book => book.Quantity <= 0).Include(book => book.Category).ToList();
                    books = SearchList(search, books);
                    return Ok(books);
                }
                else if (quantityFilter <= 9)
                {
                    List<Book> books = db.Books.Where(book => book.Quantity <= 9 && book.Quantity > 0).Include(book => book.Category).ToList();
                    books = SearchList(search, books);
                    return Ok(books);
                }
                else if (quantityFilter > 9)
                {
                    List<Book> books = db.Books.Where(book => book.Quantity > 9).Include(book => book.Category).ToList();
                    books = SearchList(search, books);
                    return Ok(books);
                }
                else
                {
                    List<Book> books = db.Books.Include(book => book.Category).ToList();
                    books = SearchList(search, books);
                    return Ok(books);
                }
            }
        }
        */
        [HttpGet]
        public IActionResult Details(int id)
        {
            Book? book = null;
            using (BookStoreContext db = new BookStoreContext())
            {
                book = db.Books.Where(book => book.Id == id).Include(book => book.Category).FirstOrDefault();
            }
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        /*
        [HttpPost]
        public IActionResult BuyBook(SellData data)
        {
            if(!ModelState.IsValid)
                return BadRequest("Il form non è stato completato con successo.");

            Book? bookToSell;
            using (BookStoreContext db = new BookStoreContext())
            {
                bookToSell = db.Books.Where(book => book.Id == data.BookId).FirstOrDefault();
            }

            if (bookToSell != null)
            {
                using (BookStoreContext db = new BookStoreContext())
                {

                    bookToSell = db.Books.Where(book => book.Id == data.BookId).FirstOrDefault();
                    bookToSell.Quantity -= data.Quantity;
                   
                    SellLog sellLog = new(DateTime.Now, data.Quantity, data.Customer, data.Quantity*bookToSell.Price);
                    sellLog.BookId = data.BookId;
                    db.SellLog.Add(sellLog);
                    db.SaveChanges();
                }
                return Ok("Aqcuisto conscluso con ");
            }
            else
            {
                return BadRequest("Qualcosa è andato storto, il libro non è presente.");
            }
        }

        [HttpGet]
        public IActionResult BestSellers()
        {
            using(BookStoreContext db = new BookStoreContext())
            {
                List<SellLog> sellLogs = db.SellLog.Include(selllog=>selllog.Book).Include(selllog=>selllog.Book.Category).ToList();

                var obj = db.SellLog.Include(selllog => selllog.Book)
                    .Where(x => x.Date > DateTime.Now.AddDays(-30))
                    .GroupBy(x => new { x.BookId, x.Book.Author, x.Book.Title , x.Book.UrlImage, x.Book.Price})
                    .Select(x => new { Book = x.Key, Sum = x.Sum(item => item.Quantity) })
                    .Where(x => x.Sum >5)
                    .OrderByDescending(x => x.Sum).ToList();


                //New crea un oggetto anonimo, non capisco come fa, ma ha 2 interi come attributi,
                //forse creando un modello del genere si potrebbe usare, per JS funziona perchè quello non fa domando ma volevo fare il calcolo qui
                return Ok(obj);
            }
        }
        */
        [HttpGet]
        public IActionResult GetCategories()
        {
            List<Category> categories = new List<Category>();
            using(BookStoreContext db = new BookStoreContext())
            {
                categories = db.Categories.ToList();
            }
            return Ok(categories);
        }
    }
}
