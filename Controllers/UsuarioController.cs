using Biblioteca.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class UsuarioController:Controller
    {
         public IActionResult Cadastro()
        {
           
            
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioService us = new UsuarioService();
            
            us.incluirUsuario(u);
            return View();
        }

        public IActionResult Listadeusurio() // chamar a pagina de listagem de usuario
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioAdmin(this);
            return View(new UsuarioService().Listar());
        }

         public IActionResult Editarusuario(int id) // chama pagina de ediçã de usuario
        {
            
           Usuario u = new UsuarioService().Listar(id);
           return View(u);
        }

[HttpPost]
         public IActionResult Editarusuario(Usuario Usereditado) // recebe dados para edição de usuarios
        {
            
           UsuarioService us = new UsuarioService();
           us.editarUsuario(Usereditado);
           
           return RedirectToAction("Listadeusurio");

        }

             public IActionResult Registrarusuario()
        {
            
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioAdmin(this);
            return View();
        }

[HttpPost]

             public IActionResult Registrarusuario(Usuario Novouser)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioAdmin(this);

            Novouser.Senha=Cryptographya.TextoCryptographado(Novouser.Senha);

            UsuarioService us = new UsuarioService();
            us.incluirUsuario(Novouser);
            return RedirectToAction("Cadastrorealizado");
        }

        public IActionResult Excluirusuario(int id){
            return View(new UsuarioService().Listar(id));
        }

        [HttpPost]

        public IActionResult Excluirusuario(string decisao, int id){
            if(decisao == "EXCLUIR"){
                ViewData["message"] = "Exclusão do usuario"+ new UsuarioService().Listar(id).Nome+ " realizado com sucesso";
                return View("Listadeusurio",new UsuarioService().Listar());
            }else{
                
                 ViewData["message"] = "Exclusão cancelada";
                 
                
            } return View("Listadeusurio", new UsuarioService().Listar());

        }

        public IActionResult Cadastrorealizado(){
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioAdmin(this);
            return View();
        }

        public IActionResult NeedAdmin(){
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult sair(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
                 
        }

       
    }
        
    }
