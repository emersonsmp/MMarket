<?php

	$method = $_SERVER['REQUEST_METHOD'];
	
	//CABECALHO DA CONEXAO
	$conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
		die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());


    if($method == 'GET'){
            
            $id = $_GET['id_pedido'];
            
                $query = "SELECT pedido.idpedido, pedido.total, pedido.Troco, pedido.TipoPagamento,
                item.id, item.cod_barra, item.Quantidade,produto.nome AS nomeProd, produto.peso, 
                pedido.Cliente_cpf, cliente.nome, cliente.endereco, cliente.numero

                FROM pedido INNER JOIN item INNER JOIN pedido_item INNER JOIN cliente INNER JOIN produto

                ON pedido.idpedido = pedido_item.Pedido_idpedido
                AND pedido_item.Item_cod_barra = item.cod_barra 
                AND item.cod_barra = produto.cod_barra
                AND pedido.Cliente_cpf = cliente.cpf
                AND item.id = pedido_item.Item_id

                WHERE pedido.idpedido = $id ";

                
                $result = mysqli_query($conexao, $query);
	            if (!$result)
	    	    "Erro de conexão com banco de dados, o seguinte erro ocorreu -> ";
	
                $rows = array();
                $produto = array();
                $rows['quant'] = mysqli_num_rows($result);

    
                $flag = 1;
                while($r = mysqli_fetch_assoc($result)) {

                    if($flag == 1){

                        $rows['id'] = $r['idpedido'];

                        $rows['cliente'] ['nomeCliente'] = $r['nome'];
                        $rows['cliente'] ['endereco'] = $r['endereco'];
                        $rows['cliente'] ['num'] = $r['numero'];
                        $rows['cliente'] ['cpf'] = $r['Cliente_cpf'];

                        $rows['pagamento'] ['total'] = $r['total'];
                        $rows['pagamento'] ['confirmacao'] = $r['Pagamento'];
                        $rows['pagamento'] ['TipoPagamento'] = $r['TipoPagamento'];

                        $flag = 0;
                    }

                    $produto['cod_barra']  = $r['cod_barra'];
                    $produto['quantidade'] = $r['Quantidade'];
                    $produto['nomeProduto'] = $r['nomeProd'];
                    $produto['peso'] = $r['peso'];

                    $rows['itens'][] = $produto;
                 }
        
                 echo json_encode($rows);                
                
    }
        
?>



