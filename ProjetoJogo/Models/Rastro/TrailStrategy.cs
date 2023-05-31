using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogo.Models.Rastro
{
    //Classe abstrata que define a estratégia para determinar quando adicionar uma nova parte ao rastro
    public abstract class TrailStrategy
    {
        /* Método abstrato que deve ser implementado pelas subclasses para determinar se o rastro 
         * está pronto para adicionar uma nova parte ou não*/
        public abstract bool Ready(Vector2 position);
    }
}
