// Menu Hambúrguer - Responsividade
document.addEventListener('DOMContentLoaded', function() {
    const hamburguer = document.querySelector('.hamburguer');
    const linksMeio = document.querySelector('.linksMeio');
    
    if (hamburguer) {
        hamburguer.addEventListener('click', function() {
            hamburguer.classList.toggle('ativo');
            linksMeio.classList.toggle('ativo');
        });
        
        // Fechar menu ao clicar em um link
        const links = linksMeio.querySelectorAll('a');
        links.forEach(link => {
            link.addEventListener('click', function() {
                hamburguer.classList.remove('ativo');
                linksMeio.classList.remove('ativo');
            });
        });
    }
});

// Navegação - Links dos botões
document.querySelector(".botaoVerProgramacao").onclick = function() {
    window.location.href = "programacao.html";
};

document.querySelector(".botaoInscrevaPrimeiraSecao").onclick = function() {
    window.location.href = "formulario.html";
};

const botaoFazer = document.querySelector("#botaoFazerinscricao");
if (botaoFazer) {
    botaoFazer.onclick = function() {
        window.location.href = "formulario.html";
    };
}
