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

            List<Modelo.Entidades.ECompleteSentences> Lista_de_complete_sentences = completesentences.Lista_de_Complete_Sentences();


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


        [HttpGet("SimplePresentPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.ESimplePresent>> ConsultarSimplePresentPrm()
        {
            Models.SimplePresent simplepresent = new Models.SimplePresent();

            List<Modelo.Entidades.ESimplePresent> Lista_de_simple_present = simplepresent.Lista_de_simple_present();

            return Lista_de_simple_present;
        }

        [HttpGet("PrepositionsOfTimePRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EPrepositionsOfTime>> ConsultarPrepositionsOfTimePrm()
        {
            Models.PrepositionsOfTime prepositionsOfTime = new Models.PrepositionsOfTime();

            List<Modelo.Entidades.EPrepositionsOfTime> Lista_de_prepositionsOfTime = prepositionsOfTime.Lista_de_prepositions_Of_Time();

            return Lista_de_prepositionsOfTime;
        }



        [HttpGet("FamilyvocabularyPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EFamilyVocabulary>> ConsultarFamilyvocabularyPrm()
        {
            Models.Family family = new Models.Family();

            List<Modelo.Entidades.EFamilyVocabulary> list_family = family.Lista_de_Family();

            return list_family;
        }

        [HttpGet("AnySomePRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EAnySome>> ConsultarAnySomePrm()
        {
            Models.AnySome anysome = new Models.AnySome();

            List<Modelo.Entidades.EAnySome> list_any_some = anysome.Lista_de_Any_Some();

            return list_any_some;
        }

        [HttpGet("VerbToBeSentencesPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EVerbToBe>> ConsultarVerbToBePrm()
        {
            Models.VerbToBe verbtobe = new Models.VerbToBe();

            List<Modelo.Entidades.EVerbToBe> list_verbtobe = verbtobe.Lista_de_verbtobe();

            return list_verbtobe;
        }

        [HttpGet("QuantifiersSentencePRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EQuantifiers>> ConsultarQuantifiersSentencePrm()
        {
            Models.Quantifiers quantifiers = new Models.Quantifiers();

            List<Modelo.Entidades.EQuantifiers> list_quantifiers = quantifiers.Lista_de_quantifiers();

            return list_quantifiers;
        }

        [HttpGet("QuestionsWithHowPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EQuestionWithHow>> ConsultarQuestionsWithHow()
        {
            Models.QuestionsWithHow questionswithhow = new Models.QuestionsWithHow();

            List<Modelo.Entidades.EQuestionWithHow> list_questionwithhow = questionswithhow.Lista_de_questionWithHow();

            return list_questionwithhow;
        }

        [HttpGet("CategoriesPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.ECategories>> ConsultarCategories()
        {
            Models.Categories categories = new Models.Categories();

            List<Modelo.Entidades.ECategories> list_categories = categories.Lista_de_Categories();

            return list_categories;
        }


        [HttpGet("PagesPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EPages>> ConsultarPages()
        {
            Models.Pages pages = new Models.Pages();

            List<Modelo.Entidades.EPages> list_pages = pages.Lista_de_pages();

            return list_pages;
        }


        [HttpGet("VocabularyPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EVocabulary>> ConsultarVocabulary()
        {
            Models.Vocabulary vocabulary = new Models.Vocabulary();

            List<Modelo.Entidades.EVocabulary> list_vocabulary = vocabulary.Lista_de_vocabulary();

            return list_vocabulary;
        }


        [HttpGet("VocabularyClothesPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EVocabularyClothes>> ConsultarVocabularyClothes()
        {
            Models.VocabularyClothes vocabularyclothes = new Models.VocabularyClothes();

            List<Modelo.Entidades.EVocabularyClothes> list_vocabulary_clothes = vocabularyclothes.Lista_de_vocabulary_clothes();

            return list_vocabulary_clothes;
        }



        [HttpGet("VocabularyFamilyPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.EVocabularyFamily>> ConsultarVocabularyFamily()
        {
            Models.VocabularyFamily vocabularyFamily = new Models.VocabularyFamily();

            List<Modelo.Entidades.EVocabularyFamily> list_vocabulary_family = vocabularyFamily.Lista_de_vocabulary_family();

            return list_vocabulary_family;
        }


        [HttpGet("SendReport/{report}")]
        public ActionResult<Result> SendReport(string report)
        {
            Models.UsuarioPRM usuario = new Models.UsuarioPRM();
            return usuario.SendReport(report);
        }



        [HttpGet("SuperlativesPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.ESuperlaivesSentences>> ConsultarSuperlativesSentencesPrm()
        {
            Models.SuperlativesSentences superlatives = new Models.SuperlativesSentences();

            List<Modelo.Entidades.ESuperlaivesSentences> Lista_de_superlatives_sentences = superlatives.Lista_de_superlatives_Sentences();


            return Lista_de_superlatives_sentences;

        }

        [HttpGet("SuperlativesAdjectivesPRM/")]
        public ActionResult<IEnumerable<Modelo.Entidades.ESuperlatives>> ConsultarSuperlativesadjectives()
        {
            Models.AdjectivesSuperlatives adjectivessuperlatives = new Models.AdjectivesSuperlatives();

            List <Modelo.Entidades.ESuperlatives> Lista_de_adjectives = adjectivessuperlatives.Lista_de_AdjectivesSuperlatives();

            return Lista_de_adjectives;
        }

    }
}
