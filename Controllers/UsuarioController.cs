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
            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem() // chamar a pagina de listagem de usuario
        {
           UsuarioService u = new UsuarioService();
           List<Usuario> listarUsuario = u.Listar();
            return View(listarUsuario);
        }

         public IActionResult Editar(int id) // chama pagina de ediçã de usuario
        {
            
           Usuario usuarioEncontrado = new UsuarioService().Listar(id);
           return View(usuarioEncontrado);
        }

[HttpPost]
         public IActionResult Editar(Usuario Usereditado) // recebe dados para edição de usuarios
        {
            
           UsuarioService us = new UsuarioService();
           us.editarUsuario(Usereditado);
           
           return RedirectToAction("Listagem");

        }

           

        public IActionResult Excluirusuario(int id){
            UsuarioService us = new UsuarioService();
             us.excluirUsuario(id);
            return RedirectToAction("Listagem");
            
        }

       
        

       

        public IActionResult NeedAdmin(){
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult sair(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
                 
        }

        // o codigo abaixo é omesmo cadastrar usuario



        /*
         public IActionResult Cadastrorealizado(){
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioAdmin(this);
            return View();
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
        */

       
    }
        
    }
