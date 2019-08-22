# Welcome to FightClub
## -----------------------------------
First Rule: Don't talk about it.
## -----------------------------------
![FightClub](https://cdn.vox-cdn.com/uploads/chorus_image/image/63301446/03__1_.0.jpg)

>### Objective:
>Utilize the provided interfaces in order to create a console application game where your user is faced with a series of `Enemy`'s to fight.

### Notes:
- Utilize `Enemy`'s `NearbyEnemies` dictionary property in combination with the logic you'll write within the `EngageNewEnemy` method to establish a `LinkedList`.

  - It's up to you on how to implement this logic (eg., maybe you can only move on to other NearbyEnemies after the `CurrentEnemy` is defeated).

- Remember to `null` check all of your local variables when working with `List.Find(`&lt;predicate&gt;`)`.

- Remember to utilize `Dictionary.ContainsKey(`&lt;string&gt;`)` before attempting to access a KeyValuePair within the dictionary.

- Remember to utilize `String.Split(`&lt;char&gt;`)` and `string command` and `string option` to simplify your `switch` statement logic within `DisplayMenu()`.