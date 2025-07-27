﻿using AgendaWeb.Infra.Data.Entities;
using AgendaWeb.Infra.Data.Interfaces;
using AgendaWeb.Infra.Data.Utils;
using AgendaWeb.Presentation.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace AgendaWeb.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IusuarioRepository _usuarioRepository;

        public AccountController(IusuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //procurar o usuario no bando de dados atraves do email e senha
                    var usuario = _usuarioRepository.GetByEmailESenha(model.Email, CriptografiaUtil.GetMD5(model.Senha));

                    if(usuario != null)
                    {
                        TempData["MensagemSucesso"] = $"Parabéns, {usuario.Nome}! Acesso ao sistema realizado com sucesso.";
                        /*
                         
                        // ****forma sem model e json

                          //gravar o nomme do usuário autenticado em sessão e id 
                          HttpContext.Session.SetString("nome_usuario", usuario.Nome);
                          HttpContext.Session.SetString("id_usuario", usuario.Id.ToString());

                        // ****forma sem model e json
                        */

                        var userIdentityModel = new UserIdentityModel
                        {
                            Id = usuario.Id,
                            Nome = usuario.Nome,
                            Email = usuario.Email,
                            DataInclusao = usuario.DataInclusao,
                            DataHoraAcesso = DateTime.Now
                        };

                        //converter o objeto em json
                        var json = JsonConvert.SerializeObject(userIdentityModel);
                        HttpContext.Session.SetString("usuario", json);

                        #region Criando a permissão de acesso do usuário

                        var autorizacao = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, usuario.Id.ToString()) },
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        var claimPrincipal = new ClaimsPrincipal(autorizacao);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);

                        #endregion



                        //redirecionar para a página inicial do projeto
                        return RedirectToAction("Index", "Home"); //Home/Index

                    }
                    else
                    {
                        TempData["MensagemErro"] = "Acesso negado! Usuário inválido!";
                    }
                }
                catch(Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }

            }
            else
            {

            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //verificar se email está cadastrado no banco
                    if(_usuarioRepository.GetByEmail(model.Email) != null)
                    {
                        TempData["MensagemErro"] = $"O email informado já existe, tente outro!";
                    }
                    else
                    {
                        var usuario = new Usuario();

                        usuario.Id = Guid.NewGuid();
                        usuario.Nome = model.Nome;
                        usuario.Email = model.Email;
                        usuario.Senha = CriptografiaUtil.GetMD5(model.Senha);
                        usuario.DataInclusao = DateTime.Now;

                        _usuarioRepository.Create(usuario); //cadastrando o usuário

                        TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                        ModelState.Clear(); //limpar os campos do formulário

                    }

                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }
            return View(model);
        }
        [Authorize]
        public IActionResult UserData()
        {
            return View();
        }

        [Authorize]
        public IActionResult LogOut()
        {
            //apagar os dados do usuário da sessão 
            HttpContext.Session.Remove("usuario");
            //apagar a permissão dada ao usuário autenticado
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //redirecionar para a tela de login
            return RedirectToAction("Login");

        }
    }
}
