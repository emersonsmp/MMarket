<?php
    $method = $_SERVER['REQUEST_METHOD'];
    
	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
		
	
	//FUNCOES POST
	if($method == 'POST'){

            $IdCupom = $_POST['IdCupom']; 
            $cod = (int)$IdCupom;

		    $query = "DELETE FROM `cupom` WHERE `cod`= $cod ";
            
            $result = mysqli_query($conexao, $query);

		    if (!$result){		    
		        $resposta = array('sucess'=>'error', 'message'=>'400');
		        echo json_encode($resposta); 
		    }else{		    
		        $resposta = array('sucess'=>'sucess', 'message'=>'200');
		        echo json_encode($resposta);
            }   
    }
	    
?>