# Demo Async
S�nario -> Pr�paration d'un repas

## M�thodes
 - Caf�
    - D�marrer la machine (33s)
    - Service le caf� (12s)
 - Salade
    - Couper les 4 l�gumes (10s + 5s par l�gumes)
    - Pr�parer la salade (10s)
  	- Ajouter la vinaigrette (5s)
 - Repas
    - Chauffer la poele (21s)
    - Faire la cuire le repas (21s)
 - Service l'ap�ro (4s)

## Note
 - Pour des op�ration E/S : 
   M�thode "async/await" qui retourne une task.
 - Pour traitement utilisant le CPU :
   Utilise de "Task.run" qui cr�er un thread en arriere plan

## Bonne pratique
 - Ne pas utiliser la syntaxe async/await si le code n'est suspendable.
 - Ajouter le suffixe "Async" sur les m�thodes asynchrone.
 - Eviter d'utiliser des objets globaux.
 - D�finir avec pr�caution du code qui combine du traitement asynchrone avec LinQ _(Utilisation d'async lambda dans les m�thodes de LinQ)_.

## Documentation
https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios