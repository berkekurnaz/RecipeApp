# Open Source Recipe App

The open source, recipes app is in this repository.<br>

This open source application was developed to share your recipes.
Gives you a dashboard for managing this blog page.
You can add articles, manage members, and read reviews in the admin panel.<br>

It is also extremely easy to install.
Download the Recipe app file and upload it to the server.Then enter the dashboard and edit your recipe blog.Everything's ready in five minutes.<br>

You can also edit the application as desired using the source code here.
Make improvements to the code and let everyone use it cheerfully.<br>

Download Recipe App For Web : [Download Recipe App](https://github.com/berkekurnaz/RecipeApp/RecipeApplication/recipeapp.rar)

## What's Inside
- This application includes a dashboard for control
- General structure is the appearance of a blog site
- Allows you to become a member and comment on blog posts
- There is a contact page for visitors to contact you.

## How To Install ?
1-) [Download Recipe App](https://github.com/berkekurnaz/RecipeApp/RecipeApplication/recipeapp.rar) <br>
2-) Upload the downloaded file to your server. <br>
3-) Go to www.yoursite.com/Yonetici/Giris route. <br>
4-) Enter **`admin`** in the Username field. <br>
5-) Enter **`1111`** in the Password field. <br>
6-) Enter the dasboard and edit everything you want.  <br>

## Developers
| Name Surname | Country | City | Github | Website |
| :-------------: |:-------------:|:-----:| :-------------:| :-------------:|
| Berke Kurnaz      | Turkey | Balıkesir | [Github Profil](https://github.com/berkekurnaz) | [Website](https://www.berkekurnaz.com)

## Contact
| Contact Type        | Contact          
| ------------- |:-------------:|
| Mail    | kurnaz.berke1907@gmail.com |

## Versions
| Version Name       | Created Date | Is Stable | Download Link         
| :-------------: |:-------------:| :-------------:| :-------------:|
| 1.0.0    | 08/05/2019 | Yes | [Download](https://github.com/berkekurnaz/RecipeApp/RecipeApplication/recipeapp.rar)

## Images
![Recipe App-1](https://github.com/berkekurnaz/RecipeApp/RecipeApplication/rec1.png)
![Recipe App-2](https://github.com/berkekurnaz/RecipeApp/RecipeApplication/rec2.png)
![Recipe App-3](https://github.com/berkekurnaz/RecipeApp/RecipeApplication/rec3.png)

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
