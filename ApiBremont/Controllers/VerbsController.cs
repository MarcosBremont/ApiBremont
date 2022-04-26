using ApiBremont.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBremont.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerbsController : ControllerBase
    {
        private string ContentRoot { get; set; }
        public VerbsController(IConfiguration configuration)
        {
            this.ContentRoot = configuration.GetValue<string>(WebHostDefaults.ContentRootKey).ToString();
        }

        [HttpGet("ObtenerVerbos/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EVerbos>> ConsultarListadoDeVerbos()
        {
            Models.Verbos verbos = new Models.Verbos();

            List<Modelo.Entidades.EVerbos> Lista_de_verbos = verbos.Lista_de_verbos();

            return Lista_de_verbos;
        }

        [HttpGet("Posiciones/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EPosiciones>> ConsultarListadoDePosiciones()
        {
            Models.Posiciones posiciones = new Models.Posiciones();

            List<Modelo.Entidades.EPosiciones> Lista_de_posiciones = posiciones.Lista_de_posiciones();

            return Lista_de_posiciones;
        }

        [HttpGet("EnterToTheTournament/{nombrePersona}/{numeroVerbosCorrectos}/{direccion}")]
        public ActionResult<Result> SetHistorialProgresoOrden(string nombrePersona, int numeroVerbosCorrectos, string direccion)
        {
            Models.Posiciones posiciones = new Models.Posiciones();
            return posiciones.EnterToTheTournament(nombrePersona, numeroVerbosCorrectos, direccion);
        }

        
        [HttpGet("SendEmails/{email}")]
        public ActionResult<Result> SendEmails(string email)
        {
            Models.UsuarioPRM usuario = new Models.UsuarioPRM();
            return usuario.SendEmails(email);
        }

        [HttpGet("WasWereSentencesprm/")] 
        public ActionResult<IEnumerable<Modelo.Entidades.EWasWereSentencesprm>> ConsultarWasWereSentencesprm()
        {
            Models.WasWereSentencesprm wasweresentencesprm = new Models.WasWereSentencesprm();

            List<Modelo.Entidades.EWasWereSentencesprm> Lista_de_Sentences = wasweresentencesprm.Lista_de_Sentences();

            return Lista_de_Sentences;
        }

        [HttpGet("MatchSentencesPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EMatchSentences>> ConsultarMatchSentencesPrm()
        {
            Models.MatchSentences matchsentences = new Models.MatchSentences();

            List<Modelo.Entidades.EMatchSentences> Lista_de_match = matchsentences.Lista_de_Match();

            return Lista_de_match;
        }

        [HttpGet("CompleteSentencesPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.ECompleteSentences>> ConsultarCompleteSentencesPrm()
        {
            Models.CompleteSentences completesentences = new Models.CompleteSentences();

            List<Modelo.Entidades.ECompleteSentences> Lista_de_complete_sentences = completesentences.Lista_de_Complete_Sentences ();


            return Lista_de_complete_sentences;
        }

        [HttpGet("AdjectivesPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EAdjectives>> ConsultarAdjectivesPrm()
        {
            Models.Adjectives adjectives = new Models.Adjectives();

            List<Modelo.Entidades.EAdjectives> Lista_de_adjectives = adjectives.Lista_de_Adjectives();

            return Lista_de_adjectives;
        }

        [HttpGet("ClothesPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EClothes>> ConsultarClothesPrm()
        {
            Models.Clothes clothes = new Models.Clothes();

            List<Modelo.Entidades.EClothes> Lista_de_clothes = clothes.Lista_de_clothes();

            return Lista_de_clothes;
        }

        [HttpGet("PronounsPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EPronouns>> ConsultarPronounsPrm()
        {
            Models.Pronouns pronouns = new Models.Pronouns();

            List<Modelo.Entidades.EPronouns> Lista_de_pronouns = pronouns.Lista_de_pronouns();

            return Lista_de_pronouns;
        }



    }
}
