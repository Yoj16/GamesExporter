# GamesExporter - LinQ

## Description
**GamesExporter** est une application console en C# permettant de :
- Lire des données de jeux vidéo à partir d'un fichier JSON.
- Rechercher, trier et grouper les jeux selon différents critères.
- Exporter les données des jeux au format XML.
- Afficher les informations des jeux dans la console.

## Fonctionnalités
1. **Lecture des données JSON** : Chargement des données de jeux depuis un fichier JSON.
2. **Recherche par nom** : Recherche des jeux contenant un mot-clé dans leur nom.
3. **Tri par score** : Tri des jeux par leur score, du plus élevé au plus faible.
4. **Groupe par éditeur** : Regroupement des jeux par éditeur.
5. **Exportation en XML** : Exportation des données des jeux dans un fichier XML.
6. **Affichage des jeux** : Affichage des informations des jeux dans la console.

## Prérequis
- **.NET 8.0** ou version ultérieure.
- Un éditeur de code comme **JetBrains Rider** ou **Visual Studio**.

## Structure du Projet
- GamesExporter/Models/ : Contient les modèles de données (ex. Game).
- GamesExporter/Services/ : Contient les services pour la lecture JSON, l'exportation XML et l'affichage.
- GamesExporter/Program.cs : Point d'entrée principal de l'application.