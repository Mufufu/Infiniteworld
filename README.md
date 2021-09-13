# Infiniteworld 
This script works for a world of 8x8 pieces of identical size, preferably terrains. You shall change the code to adapt it to your size, or add variables yourself. It's easy, I commented all.

HOW IT WORKS

You need to build your world with terrains or other objects that you will store as prefabs. Each of them must have the same size.

Each piece of world will have the script Regione.cs, where you will store their coordinates. The coordinates are basically the transform position of the piece itself.

The script Mondo.cs will store the pieces as variables in a struct. Carefully put them in order, from the bottom right to the top left.

Edit the variables inside following the comments instructions

Once you prepared everything, save the gameobject with Mondo.cs as prefab and put it alone in a scene, there's no need to put the pieces of world too.
