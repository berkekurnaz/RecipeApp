# Open Source Recipe App

The open source, recipes app is in this repository.


## What's Inside
What's Inside

## How To Install ?
How To Install

## Developers
Berke Kurnaz

## Contact
Contact

## Images
Images

## Api Usage

#### Articles Api
Route | Http Verb | Post Body | Description
--- | --- | --- | ---
/api/ AArticles/ apiKey | `GET` | Empty | List All Articles
/api/ AArticles/ articleId/ apiKey | `GET` | Empty | Show Article By Id Number
/api/ AArticles/ articleId/ count/ apiKey | `GET` | Empty | List Articles By Count

#### Category Api
Route | Http Verb | Post Body | Description
--- | --- | --- | ---
/api/ ACategories/ apiKey | `GET` | Empty | List All Categories
/api/ ACategories/ categoryId/ apiKey | `GET` | Empty | Show Category By Id Number
/api/ ACategories/ categoryId/ count/ apiKey | `GET` | Empty | List Categories By Count

#### Contacts Api
Route | Http Verb | Post Body | Description
--- | --- | --- | ---
/api/ AContacts/ apiKey | `GET` | Empty | List All Contacts
/api/ AContacts/ contactId/ apiKey | `GET` | Empty | Show Contact By Id Number
/api/ AContacts/ contactId/ count/ apiKey | `GET` | Empty | List Contacts By Count
/api/ AContacts/ apiKey | `POST` |  { NameSurname, Mail, Title, Content, CreatedDate }  | Create New Contact
/api/ AContacts/ contactId/ apiKey | `PUT` |  { NameSurname, Mail, Title, Content, CreatedDate }  | Update Contact By Id
/api/ AContacts/ contactId/ apiKey | `DELETE` |  Empty  | Delete Contact By Id

#### Comments Api
Route | Http Verb | Post Body | Description
--- | --- | --- | ---
/api/ AComments/ articleId/apiKey | `GET` | Empty | List All Comments By Article Id
/api/ AComments/ articleId/ commentId/ apiKey | `GET` | Empty | Show Comment By Id Number

#### Settings Api
Route | Http Verb | Post Body | Description
--- | --- | --- | ---
/api/ ASettings/ apiKey | `GET` | Empty | Show Setting Information By Setting Id Number
