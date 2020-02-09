<?php
$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
if (!$conexao){
    die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());
}

$banco = mysqli_select_db($conexao,"u522997124_app");
if (!$banco){
	die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
}

$method = $_SERVER['REQUEST_METHOD'];


if($method == 'POST'){
    
    
    $cpf = $_POST['cpf'];
    $cnpj = $_POST['cnpj'];
    $estrelas = $_POST['estrelas'];
    $avaliacao = $_POST['avaliacao'];
            
    $query = "INSERT INTO `avalia`(`cpf`, `mercado_cnpj`, `estrela`, `descricao`) VALUES ('$cpf','$cnpj','$estrelas',
    '$avaliacao')";
        
	$result = mysqli_query($conexao, $query);
	 if (!$result){
	   "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
	}
}

if($method == 'GET'){
    
    $cnpj = $_GET['cnpj'];
            
    $query = "SELECT mercado.nome as 'mercado',mercado.estrelas, mercado.cnpj, avalia.descricao, avalia.estrela, cliente.nome
    FROM mercado JOIN cliente JOIN avalia
    ON avalia.mercado_cnpj = mercado.cnpj AND avalia.cpf = cliente.cpf 
    WHERE avalia.mercado_cnpj = '$cnpj' ";
        
	$result = mysqli_query($conexao, $query);
	 if (!$result){
	   "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
	}
	
	$rows = array(); $i = 0;
		
    while($r = mysqli_fetch_assoc($result)) {
        if($i == 1){
            $rows['mercado']= $r['mercado'];
            $rows['rating' ]= 'Estrela'.$r['estrelas'].'.png';
        }
	    $rows['avaliacoes'][$i]['nome'] = $r['nome'];
	    $rows['avaliacoes'][$i]['descricao'] = $r['descricao'];
	    //$rows['avaliacoes'][$i]['estrela'] = "star".$r['estrela'].".png";
	    $rows['avaliacoes'][$i]['estrela'] = "Estrela".$r['estrela'].".png";
	    $i++;
    }
	
	echo json_encode($rows);
}

?>