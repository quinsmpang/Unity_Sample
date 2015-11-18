--
--------------------------------------------------------------------------------
--  FILE:  listener.lua
--  DESCRIPTION:  protoc-gen-lua
--      Google's Protocol Buffers project, ported to lua.
--      https://code.google.com/p/protoc-gen-lua/

--------------------------------------------------------------------------------
--
local setmetatable = setmetatable

module "listener"

local _null_listener = {
    Modified = function()
    end
}

function NullMessageListener()
    return _null_listener
end

local _listener_meta = {
    Modified = function(self)
        if self.dirty then
            return
        end
        if self._parent_message then
            self._parent_message:_Modified()
        end
    end
}
_listener_meta.__index = _listener_meta

function Listener(parent_message)
    local o = {}
    o.__mode = "v"
    o._parent_message = parent_message
    o.dirty = false
    return setmetatable(o, _listener_meta)
end

