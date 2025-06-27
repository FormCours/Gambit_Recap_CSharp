# Demo Async
Sénario -> Préparation d'un repas

## Méthodes
 - Café
    - Démarrer la machine (33s)
    - Service le café (12s)
 - Salade
    - Couper les 4 légumes (10s + 5s par légumes)
    - Préparer la salade (10s)
  	- Ajouter la vinaigrette (5s)
 - Repas
    - Chauffer la poele (21s)
    - Faire la cuire le repas (21s)
 - Service l'apéro (4s)

## Note
 - Pour des opération E/S : 
   Méthode "async/await" qui retourne une task.
 - Pour traitement utilisant le CPU :
   Utilise de "Task.run" qui créer un thread en arriere plan

## Bonne pratique
 - Ne pas utiliser la syntaxe async/await si le code n'est suspendable.
 - Ajouter le suffixe "Async" sur les méthodes asynchrone.
 - Eviter d'utiliser des objets globaux.
 - Définir avec précaution du code qui combine du traitement asynchrone avec LinQ _(Utilisation d'async lambda dans les méthodes de LinQ)_.

## Documentation
https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios