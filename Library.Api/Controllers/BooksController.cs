using Library.Application.Features.Book.Commands.CreateBook;
using Library.Application.Features.Book.Commands.DeleteBook;
using Library.Application.Features.Book.Commands.UpdateBook;
using Library.Application.Features.Book.Queries.GetAllBooks;
using Library.Application.Features.Book.Queries.GetBookDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<List<BookDto>> Get()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDto>> Get(int id)
        {
            var book = await _mediator.Send(new GetBookDetailsQuery(id));
            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateBookCommand book)
        {
            var response = await _mediator.Send(book);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateBookCommand book)
        {
            var command = new UpdateBookCommand
            {
                Id = id, // Usa o ID da rota
                Title = book.Title,
                Author = book.Author,
                Summary = book.Summary
            };

            await _mediator.Send(command);
            return NoContent();

        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
