# Generated by Django 2.2.7 on 2019-11-20 16:22

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('quotesApp', '0002_quote'),
    ]

    operations = [
        migrations.AddField(
            model_name='quote',
            name='favoriters',
            field=models.ManyToManyField(related_name='favoriters', to='quotesApp.User'),
        ),
    ]
