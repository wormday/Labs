class DS
 def get_mouse_info(id)
   "logic"
 end
 def get_mouse_price(id)
   100
 end
 def get_cpu_info(id)
   "pentium"
 end
 def get_cpu_price(id)
    10
 end
end

class Computer1
def initialize(computer_id,data_source)
@id=computer_id
@ds=data_source
end
def mouse
info=@ds.get_mouse_info(1)
price=@ds.get_mouse_price(1)
result="Mouse:#{info}#{price}"
end
def cpu
info=@ds.get_cpu_info(1)
price=@ds.get_cpu_price(1)
result="Cpu:#{info}#{price}"
end
end
c1=Computer1.new(1,DS.new)
puts c1.cpu
puts c1.mouse


class Computer2
def initialize(computer_id,data_source)
@id=computer_id
@ds=data_source
end

def mouse
 component :mouse
end
def cpu
 component :cpu
end

private 
def component(name)
info=@ds.send("get_#{name}_info",@id) #Symbols 支持 #{name}语法，无需转换为.to_s
price=@ds.send("get_#{name}_price",@id)
result="#{name.to_s.capitalize}:#{info}#{price}"
end
end

c2=Computer2.new(1,DS.new)
puts c2.cpu
puts c2.mouse


class Computer3
def initialize(computer_id,data_source)
@id=computer_id
@ds=data_source
data_source.methods.grep(/^get_(.)_info$/)
end
end
