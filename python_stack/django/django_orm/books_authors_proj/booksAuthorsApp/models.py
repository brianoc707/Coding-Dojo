from django.db import models

class BookManager(models.Manager):
    def validateBook(self, postData):
        print("we are in the Book Manager Validator")
        print(postData)
        errors = {}
        if len(postData['title']) < 1:
            errors['titleRequired'] = "Title of book is required"
        print(errors)
        return errors


class Author(models.Model):
    first_name = models.CharField(max_length=45)
    last_name = models.CharField(max_length=45)
    notes = models.TextField(blank = True)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

class Book(models.Model):
    title = models.CharField(max_length=45)
    desc = models.TextField(blank = True)
    authors = models.ManyToManyField(Author, related_name="books")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = BookManager()