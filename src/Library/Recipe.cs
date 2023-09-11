//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic; // Agregar esta directiva
using System.Linq;
using Full_GRASP_And_SOLID.Library;

namespace Full_GRASP_And_SOLID
{
    public class Recipe
    {
        private List<Step> steps = new List<Step>(); // Cambiar a List<Step>

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }

// esta extension sigue el principio SOLID al agregar una responsabliidad relacionada con el cálculo del costo de la producción sin modificar la clase principal.
        public double GetProductionCost()
        {
            double costInsumos = steps.Sum(step => step.Quantity * step.Input.UnitCost);
            double costEquipamiento = steps.Sum(step => (step.Time / 60) * step.Equipment.HourlyCost); // Convertir tiempo a horas
            double costoTotal = costInsumos + costEquipamiento;
            return costoTotal;
        }
    }
}
