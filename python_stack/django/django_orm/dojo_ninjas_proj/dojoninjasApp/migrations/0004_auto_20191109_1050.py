# Generated by Django 2.2.7 on 2019-11-09 15:50

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('dojoninjasApp', '0003_auto_20191108_1316'),
    ]

    operations = [
        migrations.RenameField(
            model_name='ninja',
            old_name='dojo_id',
            new_name='dojo',
        ),
    ]
