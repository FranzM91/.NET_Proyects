## Instructions for running the tests - Code First:

# 1. Make sure that Code First Migrations are enabled in the project.
> Enable-Migrations

# 2. If you database already exist and was not created by EF.
> Add-Migration InitialCreate

# 3. Apply the migration to the database.
> Update-Database

## If you want to reset the database:
> Drop-Database
> Update-Database
