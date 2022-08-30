using Backend.AspPlugins;
using Backend.Authentication;
using Backend.ParameterHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Backend.Controllers;

[ApiController]
[Route("wse")]
public class WSEController : ControllerBase
{

    private readonly AtriaContext _context;

    public WseController(AtriaContext context) {
        _context = context;
    }

    [HttpGet("{wseId:long}")]
    public WebserviceEntry Get([FromDatabase] WebserviceEntry wse) => wse;

    [RequiresAuthentication]
    [HttpPost]
    public async Task<IActionResult> EditWse(WebserviceEntry wse, [FromAuthentication] User user) {
        var existingWse = await _context.WebserviceEntries.FindAsync(wse.Id);
        if (existingWse == null) { return NotFound(); }
        var rights = existingWse.Collaborators.FirstOrDefault(x => x.UserId == user.Id)?.Rights;
        if (rights == null) { return Forbid("User is not a collaborator"); }

        if ((rights & WseRights.EditCollaborators) == 0) {
            return Forbid("Collaborator does not have the right to edit the WSE");
        }

        if (!wse.Collaborators.SequenceEqual(existingWse.Collaborators) && (rights & WseRights.EditCollaborators) == 0) {
            return Forbid("Collaborator does not have the right to edit collaborators");
        }

        if (wse.Collaborators.FirstOrDefault(x => x.UserId == user.Id)?.Rights != rights) {
            return BadRequest("You cannot modify your own rights");
        }

        if (wse.CreatedAt != existingWse.CreatedAt) {
            return BadRequest("The creation timestamp cannot be modified");
        }

        wse.Questions = existingWse.Questions;
        wse.Reviews = existingWse.Reviews;

        _context.WebserviceEntries.Update(wse);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [RequiresAuthentication]
    [HttpPost("review")]
    public async Task<IActionResult> EditReview(Review review, [FromAuthentication] User user) {
        var existingReview = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == review.Id && x.WseId == review.WseId);
        if (existingReview == null) { return NotFound(); }

        if (existingReview.CreatorId != user.Id) {
            return Forbid("Only the creator of a review can edit it");
        }

        if (review.CreatorId != user.Id) {
            return BadRequest("The creator of a review cannot be changed");
        }

        if (existingReview.CreationTime != review.CreationTime) {
            return BadRequest("The creation timestamp cannot be modified");
        }

        _context.Reviews.Update(review);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [RequiresAuthentication]
    [HttpPut]
    public async Task<IActionResult> CreateWse(WebserviceEntry wse, [FromAuthentication] User user) {
        wse.Id = 0;
        wse.CreatedAt = DateTimeOffset.UtcNow;
        wse.Collaborators = new List<Collaborator> { new() { User = user, Rights = WseRights.Owner } };
        await _context.WebserviceEntries.AddAsync(wse);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateWse), new { wseId = wse.Id }, wse);
    }

    [RequiresAuthentication]
    [HttpPut("question")]
    public async Task<IActionResult> CreateQuestion(Question question,
        [FromAuthentication] User user) {
        question.Id = 0;
        question.CreationTime = DateTimeOffset.UtcNow;
        question.Creator = user;
        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateQuestion), new { wseId = question.WseId, questionId = question.Id }, question);
    }

    [RequiresAuthentication]
    [HttpPut("answer")]
    public async Task<IActionResult> CreateAnswer(Answer answer,
        [FromAuthentication] User user) {
        answer.Id = 0;
        answer.CreationTime = DateTimeOffset.UtcNow;
        answer.Creator = user;
        await _context.Answers.AddAsync(answer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateAnswer), new { wseId = answer.WseId, questionId = answer.QuestionId, answerId = answer.Id }, answer);
    }

    [RequiresAuthentication]
    [HttpPut("review")]
    public async Task<IActionResult> CreateReview(Review review, [FromAuthentication] User user) {
        review.Id = 0;
        review.CreationTime = DateTimeOffset.UtcNow;
        review.Creator = user;
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateReview), new { wseId = review.WseId, reviewId = review.Id }, review);
    }

    [RequiresAuthentication]
    [RequiresWseRights(WseRights.DeleteWse)]
    [HttpDelete("{wseId}")]
    public async Task<IActionResult> DeleteWse([FromDatabase] WebserviceEntry wse) {
        _context.WebserviceEntries.Remove(wse);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [RequiresAuthentication]
    [HttpDelete("{wseId:long}/question/{questionId:long}")]
    public async Task<IActionResult> DeleteQuestion(long wseId, long questionId, [FromAuthentication] User user) {
        var question = await _context.Questions.FindAsync(questionId, wseId);
        if (question == null) {
            return NotFound();
        }

        if (question.Creator != user) {
            return Forbid("Only the creator can delete a question");
        }

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [RequiresAuthentication]
    [HttpDelete("{wseId:long}/question/{questionId:long}/answer/{answerId:long}")]
    public async Task<IActionResult> DeleteAnswer(long wseId, long questionId,
        long answerId, [FromAuthentication] User user) {
        var answer = await _context.Answers.FindAsync(answerId, questionId, wseId);
        if (answer == null) {
            return NotFound();
        }

        if (answer.Creator != user) {
            return Forbid("Only the creator can delete an answer");
        }

        _context.Answers.Remove(answer);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [RequiresAuthentication]
    [HttpDelete("{wseId:long}/review/{reviewId:long}")]
    public async Task<IActionResult> DeleteReview(long wseId, long reviewId, [FromAuthentication] User user) {
        var review = await _context.Reviews.FindAsync(reviewId, wseId);
        if (review == null) {
            return NotFound();
        }

        if (review.Creator != user) {
            return Forbid("Only the creator can delete a review");
        }

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
