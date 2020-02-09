<?php

    $method = $_SERVER['REQUEST_METHOD'];

    $conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
        die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
    

    //UPDATE MERCADO
    if($method == 'POST'){

        $cnpj      =  $_POST['cnpj'];
		$nome      =  $_POST['nome'];
		$endereco  =  $_POST['endereco'];
        $numero_ed =  $_POST['numero_ed'];
        $loc_lat   =  $_POST['loc_lat'];
        $loc_lng   =  $_POST['loc_lng'];
	    $email     =  $_POST['email'];
        $senha     =  $_POST['senha'];
    
        //NAO SERA PERMITIDO ALTERAR CNPJ
        $query = "UPDATE `mercado` SET `cnpj`= '$cnpj',`nome`= '$nome',`endereco`= '$endereco',
            `numero_ed`= '$numero_ed', `loc_lat`= '$loc_lat', `loc_lng`= '$loc_lng', `email`= '$email',`senha`= '$senha' WHERE cnpj = '$cnpj'";

		$conect = mysqli_query($conexao, $query);
		if (!$conect){ 
            $true = array('success' => 'false', 'message' => "Erro Na alteração");
		    echo json_encode($true);
		}else{
			$true = array('success' => 'true', 'message' => "Usuario Atualizado");
			echo json_encode($true);
		}	
    }
    
?>